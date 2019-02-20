// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function() {
    let button = $('#find-store');

    button.on('click',
        function () {
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
                    $('#repos-result').html(response)
                    $('#repos-result').show()
                    alert("success");
                },
                error: function () {
                    alert("error");
                }
            });
        })
});