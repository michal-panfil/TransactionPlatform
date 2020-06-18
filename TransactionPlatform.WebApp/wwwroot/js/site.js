// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showLogin() {
    $('#login-nav-form').toggle();
    $('#singup-nav-form').hide();
}


function showSignUp() {
    $('#singup-nav-form').toggle();
    $('#login-nav-form').hide();

}