async function regUser() {
    let userNumber = await document.getElementById("userNumber");
    let userTelegram = await document.getElementById("userTelegram");
    let url = "/api/userReg?";

    let request = await fetch(url + new URLSearchParams({UserNumber: userNumber.value, TelegramUsername: userTelegram.value}));

    try
    {
        if (request.ok === true)
        {
            let printBlock = document.getElementById("printBlock");
            let value = "Пользователь добавлен";

            printBlock.innerHTML = value;
            return await request.text();
        }
        else if(request.status === 420)
        {
            let printBlock = document.getElementById("printBlock");
            let value = "Пользователь уже существует";

            printBlock.innerHTML = value;
            return await request.text(); 
        }
        else
        {
            console.log(request.status);
        }
    }
    catch (ex)
    {
        console.log(ex);
    }
}

var regUserButton = document.userReg.userRegistration;
regUserButton.addEventListener("click", regUser)