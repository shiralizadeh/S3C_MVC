$(function () {
    $('.btn-contactus').click(function (e) {
        $('.loading').show(1000);

        var firstname = $('#Firstname').val();
        var email = $('#Email').val();
        var message = $('#Message').val();

        $.post('/ContactUs/SendMessage', {
            Firstname: firstname,
            Email: email,
            Message: message
        }).then(function (result) {
            if (result == 'True') {
                //$('form').get(0).reset();
                //$('#Firstname').val('');
                $('form input:text, form textarea').val('');

                $('form').html('<div class="alert alert-success">ثبت با موفقیت انجام شد.</div>.');
            }
            else {
                alert('رخداد خطا در ثبت اطلاعات');
            }

            $('.loading').hide(1000);
        });

        e.preventDefault();
    });
});