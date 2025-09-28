var dataTable;
var element;
$(document).ready(function () {
    loadDataTable();
    $('#EditModal').on('show.bs.modal', function (e) {
        var podaci = dataTable.row($(e.relatedTarget).closest('tr')).data();
        console.log(podaci)
        $('#prodid').val(podaci.id);
        $('#Ime').val(podaci.ime);
        $('#Prezime').val(podaci.prezime);
        $('#Email').val(podaci.email);
        $('#Datum').val(podaci.datum);
        $('#BrojTelefona').val(podaci.brojTelefona);
        $('#Status').val(podaci.status);
        $('#Reg_oznaka').val(podaci.reg_oznaka);
    })
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url": "/Termin/GetAll",
            "dataSrc": "",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "ime", "width": "5%" },
            { "data": "prezime", "width": "5%" },
            { "data": "email", "width": "5%" },
            { "data": "datum", "width": "10%"},
            { "data": "status", "width": "5%" },
            { "data": "brojTelefona", "width": "5%" },
            { "data": "reg_oznaka", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div style="display:inline-block">
                                <button class="btn btn-warning" onclick="izmeni(${data})" data-bs-toggle="modal" data-bs-target="#EditModal">Edit</button>
                                <button class="btn btn-danger" onclick="postaviId(${data})" data-bs-toggle="modal" data-bs-target="#DeleteModal">Delete</button>
                            </div>
                                   `;
                }, "width": "5%"
            }
        ]
    });
}
function postaviId(id) {
    $('#deleteId').val(id);
}

function izmeni(prodid) {
    $.ajax({
        type: "GET",
        url: "/Termin/GetOne/",
        data: { id: prodid },
        success: function (item) {
            element = item;
            
            $('#EditModal').modal('show');
        }
    })

}

$('.btnCancel').click(function () {
    window.location.href = "/CMS/Index";
})