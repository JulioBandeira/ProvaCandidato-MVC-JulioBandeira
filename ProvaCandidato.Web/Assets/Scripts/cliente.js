$(document).ready(function () {

    $('.AddUser').on('click', function () {

        $('#AddUserForm').dialog({
            autoOpen: true,
            postiion: { my: 'center', at: 'top:350', of: window },
            width: 1000,
            resizable: false,
            title: 'Adicionar Observação',
            modal: true,
            buttons: {
                'Add Observação': function () {
           
                    AddUserObs();

                },
                Cancel: function () {

                    $(this).dialog('close');
                }
            },

        });

        return false;

    });

    function AddUserObs() {

        $.ajax({
            url: '/ClienteObservacao/AddObsUser',
            type: 'Post',
            data: $('#frmObsAddInfo').serialize(),
            success: function (data) {

                window.location.href = '/Clientes/Visualisar/' + $('#Codigo_Clilente').val();
            },
            error: function (error) {

                $('#h4-obs').show();
            }
        });
    }

});