﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

export function isAlphabetKeyAndNumbers(evt) {
    var inputValue = event.which;
    // allow letters and whitespaces only.
    if (!(inputValue >= 65 && inputValue <= 120 || inputValue >= 48 && inputValue <= 57) && (inputValue != 32 && inputValue != 0)) {
        event.preventDefault();
    }
}


/*Navbar Logo */
$("#togglerBTN").click(function () {

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
