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
  .catch(err => console.error(err))
  .then(response => {

    document.querySelector('#resultSection').classList.remove('d-none');
  
      document.querySelector('#originalPass').textContent = response.originalPassword;
      document.querySelector('#encryptedPass').textContent = response.encryptedPassword;
      document.querySelector('#complexity').textContent = response.complexity.toLocaleString();
  
      
      const attemptsPerSecond = 2500000000;
      const time = response.complexity / attemptsPerSecond;
      document.querySelector('#time').textContent = time.toFixed(5);
  
      
      const strengthBar = document.querySelector('#strengthBar');
      const strengthText = document.querySelector('#strengthText'); 

      let widthPercent = (time / 3600000) * 100;
      widthPercent = Math.min(widthPercent, 100); 
      let percent = widthPercent.toFixed(5); 


    let colorClass = 'bg-danger';
    if (time > 3600000) {
      colorClass = 'bg-success';
    } else if (time > 600000) {
     colorClass = 'bg-warning';
    }


    strengthBar.className = `progress-bar ${colorClass} progress-bar-striped progress-bar-animated`;
    strengthBar.style.width = percent + '%';


    strengthText.textContent = percent + '%';
  });
  

   
  
 




}

