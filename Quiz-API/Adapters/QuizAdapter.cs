using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz_API.Models;
using Quiz_API.Persistance;
using Quiz_API.Repositories;
using Quiz_API.Services;

namespace Quiz_API.Adapters;

// Skall pussla ihop Answer och Question modellerna
public class QuizAdapter : IQuizAdapter
{
    private IQuestionRepository _questionRepository;
    private IAnswerRepository _answerRepository;
    private TriviaAdapter _triviaAdapter;

    public QuizAdapter(IQuestionRepository questionRepository, IAnswerRepository answerRepository, TriviaAdapter triviaAdapter)
    {
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
        _triviaAdapter = triviaAdapter;

    }

    // Questions:
    public List<Question> GetAllQuestions()
    {
        return _questionRepository.Get();
    }

    public Question? GetQuestionById(Guid Id)
    {
        return _questionRepository.Get(Id);
    }

    public Question SaveNewQuestion(Question question)
    {
        return _questionRepository.Post(question);
    }

    public Question? UpdateQuestion(Question question)
    {
        return _questionRepository.Put(question);
    }

    public bool DeleteQuestion(Question question)
    {
        return _questionRepository.Delete(question);
    }

    // Answers:
    public List<Answer> GetAllAnswers()
    {
        return _answerRepository.Get();
    }

    public Answer? GetAnswerById(Guid Id)
    {
        return _answerRepository.Get(Id);
    }

    public Answer SaveNewAnswer(Answer answer)
    {
        return _answerRepository.Post(answer);
    }

    public Answer? UpdateAnswer(Answer answer)
    {
        return _answerRepository.Put(answer);
    }

    public bool DeleteAnswer(Answer answer)
    {
        return _answerRepository.Delete(answer);
    }


    // Quiz
    public QuizModel? GetRandomQuizFromDb()
    {
        Question question;
        //List<Answer> answers;
        QuizModel quiz;
        var questions = _questionRepository.Get();
        if (questions.Count() > 0)
        {
            Console.WriteLine($"_________questions.Count(): {questions.Count()}");
            var random = new Random();
            int index = random.Next(questions.Count);
            Console.WriteLine($"_________index: {index}");

            question = questions[index];

            var answers = _answerRepository.Get().Where(x => x.QuestionId == question.Id).ToList();

            quiz = new QuizModel(question.Category, question.TriviaId, answers, question.Text);

            //foreach (var answer in answers)
            //    {

            //    }

            return quiz;
        }
        return null;
    }


    //public async Task<QuizModel> GetQuizFromTrivia()
    //{
    //    return (await _triviaAdapter.GetOneTriviaQuiz());
    //}

    //public async Task<IActionResult> GetTrivia()
    //{
    //    return Ok(await _quizService.GetTriviaQuiz());
    //}

    public async Task<QuizModel> GetTriviaQuiz()
    {
        return (await _triviaAdapter.GetOneTriviaQuiz());
    }

    // First Get in QuizController:
    public async Task<QuizModel> GetQuiz()
    {
        //var triviaQuiz = GetQuizFromTrivia();
        var dbQuiz = GetRandomQuizFromDb();
        var random = new Random();
        int source = random.Next(2); // 2 sources: Trivia and DB.
        Console.WriteLine($"__________source: {source}");

        //Console.WriteLine($"__________triviaQuiz.GetType: {triviaQuiz.GetType()}");


        //if (source == 0)
        //{
        //    return await GetQuizFromTrivia();
        //}
        //return GetRandomQuizFromDb();

        return (await _triviaAdapter.GetOneTriviaQuiz());

        //return  dbQuiz;
    }



    // Skall det bara finnas en generell get metod som anropas på olika sätt ifrån service? 

    // Skall ta emot ett ID och skicka tillbaka en quizmodel med rätt ID
    //public QuizModel GetQuiz(Guid id)
    //{
    //    Question question = _questionRepository.Get(id);
    //    List<Answer> listOfAnswers = _answerRepository.GetAnswerById(id);

    //    QuizModel responseQuiz = new QuizModel(question.Category, question.TriviaId, listOfAnswers, question.Text);

    //    return responseQuiz;
    //}

    //public QuizModel GetOneRandomQuiz()
    //{
    //    List<Question> Questions = _questionRepository.Get();
    //    var random = new Random();
    //    int index = random.Next(Questions.Count)-1;
    //    var chosenQuestion = Questions[index];

    //    List<Answer> Answers = _answerRepository.GetAnswers(chosenQuestion.Id);

    //    QuizModel responseQuiz = new QuizModel(chosenQuestion.Category, chosenQuestion.TriviaId, Answers, chosenQuestion.Text);
    //    return responseQuiz;
    //}

    // Finns quizzen i vår databas? I Service? 
    public bool DoesQuizExist(Guid id)
    {
        if (_questionRepository.Get().Any(x => x.Id == id))
        {
            return true;
        }

        return false;
    }

    public void Post(QuizModel quiz)
    {
        Question question = new Question(quiz.Question, quiz.TriviaId, quiz.Category);
        _questionRepository.Post(question);

        Console.WriteLine($"Post answer question: {question.Text} Id: {question.Id}");
        foreach (Answer answer in quiz.Answers)
        {
            // Need to set QuestionId here, since question get's a fresh Id i constructor above.
            answer.QuestionId = question.Id;
            Console.WriteLine($"Post answer answer: {answer.AnswerText} questionID: {answer.QuestionId}");
            _answerRepository.Post(answer);
        }
    }

    public void Put(QuizModel quiz)
    {
        Question question = new Question(quiz.Question, quiz.TriviaId, quiz.Category);
        _questionRepository.Put(question);

        foreach (Answer answer in quiz.Answers)
        {
            _answerRepository.Put(answer);
        }
    }
    public void Delete(QuizModel quiz)
    {
        Question question = new Question(quiz.Question, quiz.TriviaId, quiz.Category);
        _questionRepository.Delete(question);

        foreach (Answer answer in quiz.Answers)
        {
            _answerRepository.Delete(answer);
        }
    }



}