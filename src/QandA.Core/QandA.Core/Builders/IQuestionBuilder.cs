using QandA.Core.Answers;
using QandA.Core.Questions;
using System;
using System.Collections.Generic;

namespace QandA.Core.Builders
{
    public interface IQuestionBuilder : IBuilder<IQuestion>
    {
        IQuestionBuilder AddQuestion(IQuestion question);

        IQuestionBuilder RemoveQuestion(IQuestion question);

        IQuestionBuilder RemoveQuestion(Guid questionId);

        IQuestionBuilder AddAnswer(IQuestion question, IAnswer answer);

        IQuestionBuilder AddAnswer(Guid questionId, IAnswer answer);

        IAnswer GetAnswerById(Guid answerId);

        List<IAnswer> GetAnswersByQuestion(IQuestion question);

        List<IAnswer> GetAnswersByQuestionId(Guid questionId);

        List<IQuestion> Create();
    }
}
