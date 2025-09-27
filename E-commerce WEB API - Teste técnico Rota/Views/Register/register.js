function CheckPasswords()
{
    const password=document.getElementById("password").value;
    const passwordConfirmation= document.getElementById("confirmation_password").value;
    const form = document.getElementById("registerForm");

    form.addEventListerner("submit", function(event)
    {
        if(password==passwordConfirmation)
        {
            console.log("Senhas idênticas.");
            return true;
        }
        alert("As senhas devem ser idênticas.");   
        event.preventDefault();
        return false;
    });
}

