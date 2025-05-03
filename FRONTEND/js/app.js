function submitPassword()
{
let pass=document.querySelector('#password').value
let off=Number(document.querySelector('#offset').value)

let options = {
    method: 'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({'OriginalPassword':pass,'Offset':off})
  };
  
  fetch('https://localhost:7189/Password', options)
    .then(response => response.json())
    .then(response => console.log(response))
    .catch(err => console.error(err));




}




