using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de EloRating
/// </summary>
public class EloRating
{
    /// 
    /// Updates the scores in the passed matchup. 
    /// https://fr.wikipedia.org/wiki/Classement_Elo#Th.C3.A9orie_math.C3.A9matique
    public static Tuple<Cat, Cat> UpdateScores(Cat leftCat, Cat rightCat, double resultat, int diffFactor = 400, int kFactor = 32)

    {


        var Expected1 = GetProbaWinCat(leftCat, rightCat);
        var Expected2 = GetProbaWinCat(rightCat, leftCat);

        if (resultat == 1)
        {
            leftCat.nbvotesgagnants++;
            rightCat.nbvotesperdants++;
            leftCat.score = leftCat.score + kFactor * (1 - Expected1);
            rightCat.score = rightCat.score + kFactor * (0 - Expected2);

        }
        else if (resultat == 0)
        {
            rightCat.nbvotesgagnants++;
            leftCat.nbvotesperdants++;
            leftCat.score = leftCat.score + kFactor * (0 - Expected1);
            rightCat.score = rightCat.score + kFactor * (1 - Expected2);

        }
        else if (resultat == 0.5)
        {

            leftCat.score = leftCat.score + kFactor * (resultat - Expected1);
            rightCat.score = rightCat.score + kFactor * (resultat - Expected2);
            leftCat.nbmatchsnuls = rightCat.nbmatchsnuls = +1;
        }



        int? totalVotesCount = SessionHelper.Get<int>("totalVotesCount");
        if (!totalVotesCount.HasValue) totalVotesCount = 0;

        SessionHelper.Set<int>("totalVotesCount", (int)++totalVotesCount);
        return Tuple.Create<Cat, Cat>(leftCat, rightCat);
    }

    public static double GetProbaWinCat(Cat cat1, Cat cat2, int diffFactor = 400)
    {
        var Rating1 = Math.Pow(10, cat1.score / diffFactor);
        var Rating2 = Math.Pow(10, cat2.score / diffFactor);

        var Expected = Rating1 / (Rating1 + Rating2);
        return Expected;
    }
}