(function() {
    $(function() {

        var _questionService = abp.services.app.question;
        var _$modal = $('#QuestionCreateModal');
        var _$form = _$modal.find('form');


        $('#RefreshButton').click(function () {
            refreshUserList();
        });

        $('.delete-question').click(function () {
            var questionId = $(this).attr("data-question-id");

            deleteQuestion(questionId);
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var question = _$form.serializeFormToObject();
            abp.ui.setBusy(_$modal);
            _questionService.create(question).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshQuestionList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteQuestion(questionId) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'PhoneGames')),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _questionService.delete({
                            id: questionId
                        }).done(function () {
                            refreshQuestionList();
                        });
                    }
                }
            );
        }
    });
})();
