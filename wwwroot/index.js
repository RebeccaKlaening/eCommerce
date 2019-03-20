'use strict';

const allProducts = document.querySelector(".products");



fetch('https://localhost:5001/api/product')
    .then(response => response.json())
    .then(json => {

      const data = json;
      data.forEach(item => {

    let output = `<h3>${item.product_name.toUpperCase()}</h3>
                  <img src=${item.product_image} class="image"></img>
                  <p>Quantity: ${item.product_quantity}</p>
                  <p>Description: ${item.product_description}</p>
                  <p>Price: ${item.product_price}</p>

          `;


          allProducts.innerHTML += output;

      })

    });
