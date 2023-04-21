// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function FillQuestions(listCategoryCtrl, questionId) {
    debugger
    var questionList = $("#" + questionId);
    questionList.empty();

    var selectedCategory = listCategoryCtrl.options[listCategoryCtrl.selectedIndex].value;

    if (selectedCategory != null && selectedCategory != '') {
        $.getJSON("/home/getQuestionsByCategory", { categoryId: selectedCategory }, function (questions) {
            if (questions != null && !jQuery.isEmptyObject(questions)) {
                $.each(questions, function (index, question) {
                    questionList.append($('<option/>', {
                        value: question.id,
                        text: question.text
                    }));
                });
            }
        });
    }

    return;
}