export function ToggleButton() {

} $("#togglerBTN").click(function () {

    var btn = $("#togglerBTN");
    btn.css("pointer-events", "none");
    setTimeout(function () { btn.css("pointer-events", "auto") }, 300);


    if (document.getElementById("LogoBox").style.height == "12.2rem") {

        document.getElementById("LogoBox").style.height = "5rem";
        document.getElementById("BoxImg").style.marginTop = "-2px";

    }
    else {
        document.getElementById("LogoBox").style.height = "12.2rem";
        document.getElementById("BoxImg").style.marginTop = "65px";

    }
});