'use strict';
const handleClick = (e) => {
console.log(e.target)

let hasGuid = localStorage.getItem("eCommerce-guid");

if(hasGuid === null) {

fetchGuiD('https://localhost:5001/api/myGuid')
}

}

const fetchGuiD = (url) => {
fetch(url)
.then(res => res.json())
.then(data => {
  localStorage.setItem("eCommerce-guid", data);
})

}
const allProducts = document.querySelector(".products");

 fetch('https://localhost:5001/api/product')
    .then(response => response.json())
    .then(json => {

      const data = json;
      data.forEach(item => {

    let output = `<div class="product"><h3>${item.product_name.toUpperCase()}</h3>
                  <img src=${item.product_image} class="image"></img>
                  <p>Quantity: ${item.product_quantity}</p>
                  <p>Description: ${item.product_description}</p>
                  <p>Price: ${item.product_price}</p>
                  <button class="button">Add to cart</button> </div>
          `;


          allProducts.innerHTML += output;


      })
      const addToCart = [...document.querySelectorAll('.button')];
      addToCart.map(addButton => {
      addButton.addEventListener('click', handleClick)
})
  });
