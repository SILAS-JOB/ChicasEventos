document.addEventListener("DOMContentLoaded", function () {
    const cartContainer = document.getElementById('cart-items-container');
    const itemsFromStorage = JSON.parse(localStorage.getItem('chicasCart') || '[]');
    const orderFormModalEl = document.getElementById('orderFormModal');
    const orderFormModal = new bootstrap.Modal(orderFormModalEl);
    const orderFormModalContent = document.getElementById('orderFormModalContent');

    function loadCartItems() {
        if (itemsFromStorage.length > 0) {
            fetch('/Pages/_GetCartItemsPartial', { 
                method: 'POST',
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(itemsFromStorage)
            })
            .then(response => response.text())
            .then(html => {
                cartContainer.innerHTML = html;
            })
        } else {
            cartContainer.innerHTML = "<h5>Seu carrinho está vazio.</h5>";
        }
    }

    // ABRIR O MODAL DO FORMULÁRIO
    document.getElementById('btn-show-order-form').addEventListener('click', () => {
        fetch('/Pages/_OrderFormPartial')
            .then(response => response.text())
            .then(html => {
                orderFormModalContent.innerHTML = html;
                orderFormModal.show();
            });
    });

    // ENVIAR O ORÇAMENTO COMPLETO
    orderFormModalEl.addEventListener('submit', function (event) {
        if (event.target.id === 'order-form') {
            event.preventDefault();
            const form = event.target;
            const submitButton = orderFormModalContent.querySelector('button[type="submit"]');
            submitButton.disabled = true;
            submitButton.innerHTML = '<span class="spinner-border spinner-border-sm"></span> Enviando...';

            const formData = new FormData(form);
            const formProps = Object.fromEntries(formData);
            
            const fullOrder = {
                formData: formProps,
                cartItems: itemsFromStorage
            };

            fetch('/Pages/SendOrder', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(fullOrder)
            })
            .then(response => {
                if (!response.ok) {
                    return response.text().then(text => { throw new Error(text) });
                }
                return response.json();
            })
            .then(data => {
                orderFormModal.hide();
                localStorage.removeItem('chicasCart'); // Limpa o carrinho
                // Atualiza o contador no header (se a função estiver disponível globalmente)
                if (typeof updateCartCounter === 'function') {
                    updateCartCounter();
                }
                alert(data.message);
                window.location.href = "/"; // Redireciona para a home
            })
            .catch(error => {
                alert("Erro: " + error.message);
                submitButton.disabled = false;
                submitButton.textContent = 'Enviar Orçamento';
            });
        }
    });
    
    loadCartItems();
});