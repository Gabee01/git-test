// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function() {
    var button = $('#find-store');

    button.on('click',
        function() {
            var languages = [];
            
            $('.selected-language').each(function (language) {
                languages.push(language.val);
            });
            
            console.log(languages);
            
            $.get("/findstore",
                {
                    languages
                },
                function(response) {
                    Console.Write(response);
                    ('#repos-result').html.text(response)
                },
                function(errorMessage) {
                    Console.Write(errorMessage);
                }
            );
        });
});