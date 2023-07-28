// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// site.js
$(document).ready(function () {
    $('#editTaskModal').on('show.bs.modal', function (event) {
        let button = $(event.relatedTarget);
        let taskName = button.data('name');
        let taskDescription = button.data('description');
        let taskCreationDate = button.data('creationdate');
        let taskStatus = button.data('status');

        $('#taskName').val(taskName);
        $('#taskDescription').val(taskDescription);
        $('#taskCreationDate').val(taskCreationDate);
        $('#taskStatus').val(taskStatus ?? false); // Utiliser false comme valeur par défaut pour taskStatus si elle est undefined
    });
});
