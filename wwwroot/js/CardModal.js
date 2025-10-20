// Este é o script "gerente" de todos os modais.
// Ele ouve os cliques nos botões, carrega a partial view correta via fetch,
// e DEPOIS ativa a interatividade específica daquela partial.

document.addEventListener("DOMContentLoaded", function() {
    
    // Um único "ouvinte" de cliques no corpo da página para máxima eficiência.
    document.body.addEventListener('click', function(event) {
        
        // Função que carrega o conteúdo E ativa os scripts necessários depois do carregamento.
        function loadModalContent(url) {
            const modalBody = document.getElementById('modalBodyContent');
            if (!modalBody) return;
            
            modalBody.innerHTML = '<div class="text-center p-5"><div class="spinner-border" role="status"></div></div>';
            
            fetch(url)
                .then(response => response.text())
                .then(html => { 
                    modalBody.innerHTML = html; 

                    // A MÁGICA: Depois que o HTML é inserido, verificamos se é o formulário de Staffing.
                    const staffingForm = modalBody.querySelector('#staffing-form');
                    if (staffingForm) {
                        // Se encontramos o formulário, ativamos sua lógica específica.
                        initializeStaffingForm(staffingForm);
                    }
                })
                .catch(error => console.error("Falha ao carregar conteúdo do modal:", error));
        }

        // --- ROTEADOR DE CLIQUES ---
        // Verifica qual botão foi clicado e chama a função para carregar o conteúdo correto.

        if (event.target.matches('.btn-detalhes')) {
            const serviceId = event.target.getAttribute('data-id');
            loadModalContent(`/Pages/_ServiceDetailPartial?id=${serviceId}`);
        }
        else if (event.target.matches('.btn-pacotes')) {
            const category = event.target.getAttribute('data-category');
            loadModalContent(`/Pages/_PackagesPartial?category=${category}`);
        }
        else if (event.target.matches('.btn-show-staffing')) {
            const category = event.target.getAttribute('data-category');
            loadModalContent(`/Pages/_StaffingServicePartial?category=${category}`);
        }
        else if (event.target.matches('.btn-package-details')) {
            const packageId = event.target.getAttribute('data-id');
            loadModalContent(`/Pages/_PackageDetailPartial?id=${packageId}`);
        }
        else if (event.target.matches('.btn-voltar-pacotes')) {
            const category = event.target.getAttribute('data-category');
            loadModalContent(`/Pages/_PackagesPartial?category=${category}`);
        }
    });

    /**
     * Função que contém TODA a lógica do formulário de seleção de equipe (Staffing).
     * Ela é chamada APÓS o HTML da partial ser carregado.
     * @param {HTMLElement} form - O elemento <form> que acabou de ser carregado.
     */
    function initializeStaffingForm(form) {
        const summaryItemsList = document.getElementById('summary-items-list');
        const summaryTotal = document.getElementById('summary-total');
        const addToCartButton = document.getElementById('btn-add-staffing-to-cart');
        
        // A "memória" compartilhada que guarda a seleção válida atual.
        let currentSelectionForCart = []; 

        // Ouve qualquer mudança nos inputs do formulário.
        form.addEventListener('change', function() {
            manageDropdownStates();
            updateSummary();
        });

        function manageDropdownStates() {
            form.querySelectorAll('.staffing-service-checkbox').forEach(checkbox => {
                const select = checkbox.closest('.form-check').querySelector('.staffing-duration-select');
                if (select) {
                    select.disabled = !checkbox.checked;
                    if (!checkbox.checked) {
                        select.selectedIndex = 0;
                    }
                }
            });
        }

        function updateSummary() {
            let total = 0;
            let itemsHtml = '';
            let allValidSelectionsMade = true;
            
            // Limpa a "memória" para recalcular a cada mudança.
            currentSelectionForCart = []; 
            
            const checkedBoxes = form.querySelectorAll('.staffing-service-checkbox:checked');

            checkedBoxes.forEach(box => {
                const title = box.dataset.title;
                const serviceId = parseInt(box.value);
                let itemPrice = 0;
                let optionId = 0;
                let isValid = false;

                const select = box.closest('.form-check').querySelector('.staffing-duration-select');
                if (select) {
                    if (select.selectedIndex > 0) {
                        const option = select.options[select.selectedIndex];
                        itemPrice = parseFloat(option.dataset.price);
                        optionId = parseInt(option.value);
                        isValid = true;
                    } else {
                        allValidSelectionsMade = false;
                    }
                } else {
                    isValid = true;
                }

                if (isValid) {
                    total += itemPrice;
                    itemsHtml += `<div class="d-flex justify-content-between small"><span>${title}</span> <span>${itemPrice.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</span></div>`;
                    // Preenche a "memória" compartilhada com os itens válidos.
                    currentSelectionForCart.push({ id: serviceId, type: 'staffing', optionId: optionId }); 
                } else {
                    itemsHtml += `<div class="d-flex justify-content-between small text-warning"><span>${title}</span> <span>Selecione a duração</span></div>`;
                }
            });

            summaryItemsList.innerHTML = itemsHtml || '<span class="text-muted small">Nenhum item selecionado</span>';
            summaryTotal.textContent = total.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
            addToCartButton.disabled = checkedBoxes.length === 0 || !allValidSelectionsMade;
        }

        // Lógica do botão de adicionar ao carrinho.
        addToCartButton.addEventListener('click', function() {
            const cartItems = JSON.parse(localStorage.getItem('chicasCart') || '[]');
            let itemsAddedCount = 0;

            // Usa a "memória" compartilhada, que agora está preenchida corretamente.
            currentSelectionForCart.forEach(itemToAdd => {
                const exists = cartItems.some(cartItem => cartItem.id === itemToAdd.id && cartItem.optionId === itemToAdd.optionId && cartItem.type === itemToAdd.type);
                if (!exists) {
                    cartItems.push(itemToAdd);
                    itemsAddedCount++;
                }
            });
            
            localStorage.setItem('chicasCart', JSON.stringify(cartItems));

            if (typeof updateCartCounter === 'function') { updateCartCounter(); }
            alert(`${itemsAddedCount} novo(s) item(ns) adicionado(s) ao orçamento!`);
            
            const modalElement = document.getElementById('detailsModal');
            const modalInstance = bootstrap.Modal.getInstance(modalElement);
            if (modalInstance) { modalInstance.hide(); }
        });

        // Garante que o estado inicial está correto ao carregar
        manageDropdownStates();
        updateSummary();
    }
});