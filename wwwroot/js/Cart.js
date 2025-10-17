document.addEventListener("DOMContentLoaded", function () {

    function getCartItems() {
        const items = localStorage.getItem('chicasCart');
        return items ? JSON.parse(items) : [];
    }

    function saveCartItems(items) {
        localStorage.setItem('chicasCart', JSON.stringify(items));
    }

    function updateCartCounter() {
        const counter = document.getElementById('cart-counter');
        if (counter) {
            const items = getCartItems();
            counter.textContent = items.length;
            counter.style.display = items.length > 0 ? 'inline-block' : 'none';
        }
    }

    function addToCart(itemId, itemType) {
        let items = getCartItems();

        const existingItem = items.find(item => item.id === itemId && item.type === itemType);
        if (existingItem) {
            alert("Este item já está no seu orçamento.");
            return;
        }

        items.push({ id: itemId, type: itemType, quantity: 1 });
        saveCartItems(items);
        updateCartCounter();
        alert("Item adicionado ao seu orçamento!");
    }

    document.body.addEventListener('click', function (event) {
        if (event.target.matches('.btn-add-to-cart')) {
            const button = event.target;
            const itemId = parseInt(button.getAttribute('data-id'));
            const itemType = button.getAttribute('data-type');
            
            addToCart(itemId, itemType);
        }
    });

    updateCartCounter();
});