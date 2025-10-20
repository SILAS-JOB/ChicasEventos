

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

        if (event.target.matches('.btn-show-staffing')) {
            const category = event.target.getAttribute('data-category');
            loadModalContent(`/Pages/_StaffingServicePartial?category=${category}`);
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