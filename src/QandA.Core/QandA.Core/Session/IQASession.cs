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
        DateTime SessionStarted { get; set; }
        DateTime SessionStopped { get; set; }

        string CreateIdentityHash();

        void StartSession();

        void StopSession();

        void TryAnswer(IQuestion question, IAnswer answer);

        void TryAnswer(Guid questionId, Guid answerId);
    }
}