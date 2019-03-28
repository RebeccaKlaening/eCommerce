'use strict';
const cartItems = document.getElementById('cart-items');
if(localStorage.getItem("eCommerce-guid")){
  const userGuid = localStorage.getItem("eCommerce-guid");

  fetch('https://localhost:5001/api/cartitem'/+userGuid)
  .then(response => response.json())
  .then(json => {
    cartItems.textContent = json.items;

  });
}
