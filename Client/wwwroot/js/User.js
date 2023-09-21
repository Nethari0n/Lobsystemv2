export function ExportToExcel(type, fn, dl) {
    var elt = document.getElementById('tableFull');
    //Saves the table as an excel file.
    var wb = XLSX.utils.table_to_book(elt, { sheet: "sheet1" });
    //Removes the last column in the table from the excel file.
    var ws = wb.Sheets.sheet1;
    var range = XLSX.utils.decode_range(ws["!ref"]);
    range.e.c--;
    ws["!ref"] = XLSX.utils.encode_range(range);
    return dl ?
        //Saves the excel file.
        XLSX.write(wb, { bookType: type, bookSST: true, type: 'base64' }) :
        XLSX.writeFile(wb, fn || ('MySheetName.' + (type || 'xlsx')));
}

//Alphabet only
export function isAlphabetKey(evt) {
    var inputValue = event.which;
    // allow letters and whitespaces only.
    if (!(inputValue >= 65 && inputValue <= 120) && (inputValue != 32 && inputValue != 0)) {
        event.preventDefault();
    }
}

export function ShowEditModal() {
    var modal = document.getElementById("editModal");
    modal.style.display = "block";
    modal.classList.add("show");
}

export function CloseEditModal() {
    var modal = document.getElementById("editModal");
    modal.style.display = "none";
    modal.classList.remove("show");
}

export function ShowCreateModal() {
    var modal = document.getElementById("opretModal");
    modal.style.display = "block";
    modal.classList.add("show");

    roleChange();
}

export function CloseCreateModal() {
    var modal = document.getElementById("opretModal");
    modal.style.display = "none";
    modal.classList.remove("show");
}

export function SearchTable() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("search");
    filter = input.value.toUpperCase();
    table = document.getElementById("table");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[2];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

export function roleChange() {
    if (document.getElementById("role").value == 0) {
        document.getElementById("submitCreate").setAttribute("disabled", "");
    } else {
        document.getElementById("submitCreate").removeAttribute("disabled");
    }
}

//Toast Validation
export function SucessToast() {
    var toastLiveExample = document.getElementById('SucessToast');

    toastLiveExample.style.display = "block";
    toastLiveExample.style.opacity = "1";


    setTimeout(function () {
        toastLiveExample.style.display = "none";
        toastLiveExample.style.opacity = "0";
    }, 5000);
}

export function ErrorToast() {
    var toastLiveExample = document.getElementById('ErrorToast');

    toastLiveExample.style.display = "block";
    toastLiveExample.style.opacity = "1";


    setTimeout(function () {
        toastLiveExample.style.display = "none";
        toastLiveExample.style.opacity = "0";
    }, 5000);
}

export function ToastValidation() {
    UserNameToast();
    NameToast();
    PassToast();
    RepPassToast();
    EmailToast();
    RoleToast();
}

export function ToastValidationEdit() {
    UserNameToast();
    NameToast();
    EmailToast();
    RoleToast();
}

export function UserNameToast() {
    var value = document.getElementById("username").value;

    if (value == "" || value == null) {
        var toastLiveExample = document.getElementById('UserNameToast');

        toastLiveExample.style.display = "block";
        toastLiveExample.style.opacity = "1";


        setTimeout(function () {
            toastLiveExample.style.display = "none";
            toastLiveExample.style.opacity = "0";
        }, 5000);
    }
}

export function NameToast() {
    var value = document.getElementById("name").value;

    if (value == "" || value == null) {
        var toastLiveExample = document.getElementById('NameToast');

        toastLiveExample.style.display = "block";
        toastLiveExample.style.opacity = "1";


        setTimeout(function () {
            toastLiveExample.style.display = "none";
            toastLiveExample.style.opacity = "0";
        }, 5000);
    }
}

export function PassToast() {
    var value = document.getElementById("password").value;

    if (value == "" || value == null) {
        var toastLiveExample = document.getElementById('PassToast');

        toastLiveExample.style.display = "block";
        toastLiveExample.style.opacity = "1";


        setTimeout(function () {
            toastLiveExample.style.display = "none";
            toastLiveExample.style.opacity = "0";
        }, 5000);
    }
}

export function RepPassToast() {
    var pas = document.getElementById("password").value;
    var value = document.getElementById("repetPassword").value;

    if (value == "" && pas != "" || value == null && pas != null || pas != value) {
        var toastLiveExample = document.getElementById('RepPassToast');

        toastLiveExample.style.display = "block";
        toastLiveExample.style.opacity = "1";


        setTimeout(function () {
            toastLiveExample.style.display = "none";
            toastLiveExample.style.opacity = "0";
        }, 5000);

    }
}

export function EmailToast() {
    var value = document.getElementById("mail").value;

    if (value == "" || value == null) {
        var toastLiveExample = document.getElementById('EmailToast');

        toastLiveExample.style.display = "block";
        toastLiveExample.style.opacity = "1";


        setTimeout(function () {
            toastLiveExample.style.display = "none";
            toastLiveExample.style.opacity = "0";
        }, 5000);
    }
}

export function RoleToast() {
    var value = document.getElementById("role").value;

    if (value == "" || value == null) {
        var toastLiveExample = document.getElementById('RoleToast');

        toastLiveExample.style.display = "block";
        toastLiveExample.style.opacity = "1";


        setTimeout(function () {
            toastLiveExample.style.display = "none";
            toastLiveExample.style.opacity = "0";
        }, 5000);
    }
}