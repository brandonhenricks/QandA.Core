using QandA.Core.Answers;
using QandA.Core.Questions;
using System;
using System.Collections.Generic;

namespace QandA.Core.Session
{
    public interface IQASession<TKey>
    {
        Guid SessionId { get; set; }
        TKey Identifier { get; set; }
        List<IQuestion> ActiveQuestions { get; }
        DateTime Started { get; set; }
        DateTime Stopped { get; set; }
        void Start();
        void Stop();
        void TryAnswer(IQuestion question, IAnswer answer);
        void TryAnswer(Guid questionId, Guid answerId);
    }
}
