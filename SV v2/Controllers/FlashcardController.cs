using Microsoft.AspNetCore.Mvc;
using SV_v2.Models;
using System;
using System.Collections.Generic;

namespace SV_v2.Controllers
{
    public class FlashcardController : Controller
    {
        // Lista med flashcards
        private readonly List<Flashcard> _flashcards = new List<Flashcard>
        {
        // VARJE TEXT FÅR VARA MAX 80 KARAKTÄRER LÅNGA.
        // Rättsprinciper
        new Flashcard { Id = 1, Question = "Vad betyder Legalitetsprincipen?", Answer = "Inga åtgärder utan lagstöd; allt du gör måste vara grundat i lagen." },
        new Flashcard { Id = 2, Question = "Vad betyder Ändamålsprincipen?", Answer = "Befogenheter får endast användas för det syfte de är med lagstöd avsedda för." },
        new Flashcard { Id = 3, Question = "Vad betyder Proportionalitetsprincipen?", Answer = "Åtgärder ska stå i rimlig proportion till brottet eller hotet." },
        new Flashcard { Id = 4, Question = "Vad betyder Likabehandlingsprincipen?", Answer = "Alla är lika inför lagen, och ingen ska särbehandlas eller diskrimineras." },
        new Flashcard { Id = 5, Question = "Vad betyder Objektivitetsprincipen?", Answer = "Agera opartiskt och sakligt, basera beslut på fakta och lagar." },
        new Flashcard { Id = 6, Question = "Vad betyder Behovsprincipen?", Answer = "Våld eller tvång får användas endast vid konkret behov. Om behovet försvinner, ska åtgärden upphöra." },

        // Skyddsvaktsagerande
        new Flashcard { Id = 7, Question = "Vad är skyddsvaktens ASS?", Answer = "Armbindel, Skyddsvaktsbevis och Skjutvapen." },
        new Flashcard { Id = 8, Question = "Vad betyder UBBA-loopen?", Answer = "Upptäck, Bedöm, Besluta, Agera." },
        new Flashcard { Id = 9, Question = "Vad betyder OODA-loopen?", Answer = "Observation, Orientation, Decision, Action." },
        new Flashcard { Id = 10, Question = "Vad är 5-20 metoden?", Answer = "Används främst vid halt med fordon; först kontrollera 5 meter runt fordonet och sedan 20 meter." },
        new Flashcard { Id = 11, Question = "Vad innebär Tjänstemannaskydd?", Answer = "Att hot eller våld mot skyddsvakten i tjänst, eller som hämnd, är straffbart." },
        new Flashcard { Id = 12, Question = "Vad är skyddsvaktens primära uppgifter?", Answer = "Upptäcka, observera, rapportera, avbryta och om möjligt ingripa." },
        new Flashcard { Id = 13, Question = "Vad är syftet med skyddslagen?", Answer = "Förstärkt skydd för byggnader, fartyg, områden m.m, samt skydd för allmänheten från skador som kan uppstå till följd av militär verksamhet." },
        new Flashcard { Id = 14, Question = "Vad innebär en Invidkontroll?", Answer = "Kontrollera identifikation samt eventuell behörighet." },
        new Flashcard { Id = 15, Question = "När är man invid ett skyddsobjekt?", Answer = "Det finns ingen fysisk gräns; man är invid när man kan påverka, observera eller fotografera objektet." },
        new Flashcard { Id = 16, Question = "Vilka skyldigheter har en person som upprätthåller sig invid ett skyddsobjekt?", Answer = "Underkasta sig identifiering, underkasta sig kroppsvisitation samt visitation av medtaget fordon." },
        new Flashcard { Id = 17, Question = "Vilka åtgärder kan en skyddsvakt genomföra?", Answer = "Avvisa, avlägsna, omhänderta, gripa, beslagta, förverka." },
        new Flashcard { Id = 18, Question = "Vad är huvudförbudet på ett skyddsobjekt?", Answer = "Tillträdesförbud. Tillträdesförbudet omfattar även tillträde med hjälp av en obemannad farkost." },
        new Flashcard { Id = 19, Question = "Vad innebär tilläggsförbudet man brukar kalla Fotoförbud?", Answer = "Förbud mot att fotografera, avbilda, beskriva eller mäta skyddsobjektet utan särskilt tillstånd." },
        new Flashcard { Id = 20, Question = "Vad innebär tilläggsförbudet man brukar kalla Badförbud?", Answer = "Förbud mot att bada, dyka, ankra eller fiska." },
        new Flashcard { Id = 21, Question = "Vad för brott är det man brukar kalla de 4 stora?", Answer = "Sabotage, terrorism, spioneri, och grovt rån." },
        new Flashcard { Id = 22, Question = "Vad står LUL för?", Answer = "Lagen med särskilda bestämmelser om unga lagöverträdare." },
        new Flashcard { Id = 23, Question = "Vad står LDT för?", Answer = "Lagen om disciplinansvar inom totalförsvaret." },
        new Flashcard { Id = 24, Question = "Vad står PL för?", Answer = "Polislagen." },
        };

        // HashSet för att hålla reda på visade kort
        private static readonly HashSet<int> _shownCardIds = new HashSet<int>();
        private static readonly Random _random = new Random();

        // Visar vyn Flashcards.cshtml
        public IActionResult Index()
        {
            return View("flashcards");
        }

        // Returnerar ett slumpmässigt flashcard som JSON
        public IActionResult GetRandomCard()
        {
            // Om alla kort har visats, återställ HashSet
            if (_shownCardIds.Count == _flashcards.Count)
            {
                _shownCardIds.Clear();
                Console.WriteLine("Alla kort har visats, återställs visade kort.");
            }

            int cardId;
            do
            {
                cardId = _random.Next(1, _flashcards.Count + 1); // Generera ID mellan 1 och antalet kort
            } while (_shownCardIds.Contains(cardId));

            // Lägg till det valda kortets ID till de visade korten
            _shownCardIds.Add(cardId);
            var flashcard = _flashcards.Find(c => c.Id == cardId);

            Console.WriteLine($"Visar kort: {flashcard.Question} med ID {cardId}"); // Logg för felsökning

            return Json(flashcard);
        }
    }
}
