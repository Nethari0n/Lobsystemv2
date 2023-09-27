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
