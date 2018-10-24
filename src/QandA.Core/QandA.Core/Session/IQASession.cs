using QandA.Core.Answers;
using QandA.Core.Questions;
using System;
using System.Collections.Generic;

namespace QandA.Core.Session
{
    public interface IQASession
    {
        Guid SessionId { get; }

        IList<IQuestion> ActiveQuestions { get; }

        DateTime SessionStarted { get; }

        DateTime SessionStopped { get; }

        string CreateSessionHash();

        void StartSession();

        void StopSession();

        void TryAnswer(IQuestion question, IAnswer answer);

        void TryAnswer(Guid questionId, Guid answerId);
    }
}