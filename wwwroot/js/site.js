$(function() {
    let findButton = $('#find-store');
    
    findButton.on('click',function () {
        let languages = [];

        $('.selected-language').each(function () {
            languages.push($(this).val().toString());
        });

        $.ajax({
            method: "POST",
            url: "/Home/FindStore",
            data: {
                languages
            },
            success: function (response) {
                $('#repos-result').html(response).show();
            },
            error: function () {
                alert("error");
            }
        });
    });
});