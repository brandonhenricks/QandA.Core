using Microsoft.Extensions.Logging;
using QandA.Core.Questions;
using QandA.Core.Session;
using System.Collections.Generic;

namespace QandA.Core.Factories
{
    public interface IQASessionFactory : IFactory<IQASession>
    {
        IQASession Create(IList<IQuestion> questions);

        IQASession Create(ILogger logger, IList<IQuestion> questions);
    }
}