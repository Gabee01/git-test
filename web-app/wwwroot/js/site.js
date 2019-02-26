$(function() {
    let findButton = $('#find-store');
    
    findButton.on('click',function () {
        findButton.prop("disabled", true);
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
                findButton.prop("disabled", false);
            },
            error: function () {
                alert("error");
                findButton.prop("disabled", false);
            }
        });
    });
});