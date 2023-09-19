//Date Validation
export function OnDateChange() {
    var input = document.getElementById("endDate");
    var otherInput = document.getElementById("startDate").value;
    input.setAttribute("min", otherInput);

    if ((Date.parse(input.value) < Date.parse(otherInput))) {
        input.value = otherInput;
    }
}

export function OnEndChange() {
    var startDate = document.getElementById("startDate").value;
    var endDate = document.getElementById("endDate").value;

    if ((Date.parse(endDate) < Date.parse(startDate))) {
  
        document.getElementById("endDate").value = startDate;

    }
}

export function CheckedMulti() {
    var textField = document.getElementById("MultiTetxt");
    var check = document.getElementById("multiplyer");

    if (check.checked) {
        textField.removeAttribute('disabled');
    }
    else {
        textField.setAttribute('disabled', 'true');
    }
}

export function RemoveDisableEventAdd() {
    var btn = document.getElementById("EventAdd");
    btn.removeAttribute('disabled');
}

export function AddDisableEventAdd() {
    var btn = document.getElementById("EventAdd");
    btn.setAttribute('disabled', 'true');
}

//Property Fields Validations
export function ToastValidation() {
    ToastTitle();

    ToastStartDate();

    ToastEndDate();

    ToastType();
}

export function ToastTitle() {
    var title = document.getElementById("Title").value;

    if (title == "" || title == null) {
        var toastLiveExample = document.getElementById('TitleToast');

        toastLiveExample.style.display = "block";
        toastLiveExample.style.opacity = "1";


        setTimeout(function () {
            toastLiveExample.style.display = "none";
            toastLiveExample.style.opacity = "0";
        }, 5000);
    }
}

export function ToastType() {
    var type = document.getElementById("Types").value;

    if (type == "0" || type == 0) {
        var toastLiveExample = document.getElementById('TypeToast');

        toastLiveExample.style.display = "block";
        toastLiveExample.style.opacity = "1";


        setTimeout(function () {
            toastLiveExample.style.display = "none";
            toastLiveExample.style.opacity = "0";
        }, 5000);
    }
}

export function ToastStartDate() {
    var startDate = document.getElementById("startDate").value;
    if (startDate == "" || startDate == null) {
        var toastLiveExample = document.getElementById('StartDateToast');

        toastLiveExample.style.display = "block";
        toastLiveExample.style.opacity = "1";



        setTimeout(function () {
            toastLiveExample.style.display = "none";
            toastLiveExample.style.opacity = "0";
        }, 5000);
    }
}

export function ToastEndDate() {
    var endDate = document.getElementById("endDate").value;

    if (endDate == "" || endDate == null) {
        var toastLiveExample = document.getElementById('EndDateToast');

        toastLiveExample.style.display = "block";
        toastLiveExample.style.opacity = "1";


        setTimeout(function () {
            toastLiveExample.style.display = "none";
            toastLiveExample.style.opacity = "0";
        }, 5000);
    }
}

export function ToastSucces() {
    var toastLiveExample = document.getElementById('SucessToast');

    toastLiveExample.style.display = "block";
    toastLiveExample.style.opacity = "1";


    setTimeout(function () {
        toastLiveExample.style.display = "none";
        toastLiveExample.style.opacity = "0";
    }, 5000);
}

export function ToastDistance() {
    var toastLiveExample = document.getElementById('DistanceToast');

    toastLiveExample.style.display = "block";
    toastLiveExample.style.opacity = "1";


    setTimeout(function () {
        toastLiveExample.style.display = "none";
        toastLiveExample.style.opacity = "0";
    }, 5000);
}

export function ToastError() {
    var toastLiveExample = document.getElementById('ToastError');

    toastLiveExample.style.display = "block";
    toastLiveExample.style.opacity = "1";


    setTimeout(function () {
        toastLiveExample.style.display = "none";
        toastLiveExample.style.opacity = "0";
    }, 5000);
}

export function UpdateStartDate(str) {
    document.getElementById("startDate").value = str;
}

export function UpdateEndDate(str) {
    document.getElementById("endDate").value = str;
}
