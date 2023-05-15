function bodyInit()
{
    dlConfig();
}

function dlConfig()
{
    var ver = "v1.6.1.0";

    document.getElementById("dlID").href = "https://github.com/o7q/Keystrokes/releases/download/" + ver + "/Keystrokes.exe";
    document.getElementById("dlID").innerHTML = "Download " + ver;
}