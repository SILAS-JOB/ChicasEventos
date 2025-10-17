// // Arquivo: wwwroot/js/CardModal.js

// document.addEventListener("DOMContentLoaded", function() {
    
//     document.body.addEventListener('click', function(event) {
        
//         if (event.target.matches('.btn-detalhes')) {
            
//             const modalBody = document.getElementById('modalBodyContent');

//             if (!modalBody) {
//                 console.error("Erro: O elemento com ID 'modalBodyContent' não foi encontrado no HTML.");
//                 return; 
//             }

//             const button = event.target;
//             const serviceId = button.getAttribute('data-id');
//             const url = `/Pages/_ServiceDetailPartial?id=${serviceId}`; 

//             modalBody.innerHTML = '<div class="text-center p-5"><div class="spinner-border" role="status"></div></div>';
            
//             fetch(url)
//                 .then(response => response.text())
//                 .then(html => {
//                     modalBody.innerHTML = html;
//                 })
//                 .catch(error => {
//                     console.error("Erro ao buscar a partial view:", error);
//                     modalBody.innerHTML = "<p class='text-danger p-4'>Não foi possível carregar os detalhes.</p>";
//                 });
//         }
//     });
// });

document.addEventListener("DOMContentLoaded", function() {
    
    document.body.addEventListener('click', function(event) {
        
        // Função auxiliar para carregar conteúdo no modal
        function loadModalContent(url) {
            const modalBody = document.getElementById('modalBodyContent');
            if (!modalBody) return;
            
            modalBody.innerHTML = '<div class="text-center p-5"><div class="spinner-border" role="status"></div></div>';
            fetch(url)
                .then(response => response.text())
                .then(html => { modalBody.innerHTML = html; })
                .catch(error => console.error("Falha ao carregar conteúdo do modal:", error));
        }

        if (event.target.matches('.btn-detalhes')) {
            const serviceId = event.target.getAttribute('data-id');
            loadModalContent(`/Pages/_ServiceDetailPartial?id=${serviceId}`);
        }

        if (event.target.matches('.btn-pacotes')) {
            const category = event.target.getAttribute('data-category');
            loadModalContent(`/Pages/_PackagesPartial?category=${category}`);
        }
        
        if (event.target.matches('.btn-package-details')) {
            const packageId = event.target.getAttribute('data-id');
            loadModalContent(`/Pages/_PackageDetailPartial?id=${packageId}`);
        }

        if (event.target.matches('.btn-voltar-pacotes')) {
            const category = event.target.getAttribute('data-category');
            loadModalContent(`/Pages/_PackagesPartial?category=${category}`);
        }
    });
});