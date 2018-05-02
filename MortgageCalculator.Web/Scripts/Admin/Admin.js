$(document).ready(function () {
    $("#mortgageList").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            url: "@Url.Action('Admin', 'Index')",
            type: 'GET'
        },
        "language": {
            "emptyTable": "No data available in table"
        }
    });
});