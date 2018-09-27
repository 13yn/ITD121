using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameObjects;
using Games;

/*
 * This Console Project is for you to test the functionality of
 * your classes defined in GameObjects and Games.
 * 
 * The code here will not be assessed.
 * 
 */

class Program {
    static void Main() {
        Hand computerHand = new Hand(new List<Card> {
                new Card(Suit.Diamonds, FaceValue.Three)
            });

        Hand userHand = new Hand(new List<Card> {
                new Card(Suit.Clubs, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Four)
            });

        List<Card> discardCards = Utility.FullDeckInOrder();
        Utility.RemoveHand(discardCards, userHand);
        Utility.RemoveHand(discardCards, computerHand);
        discardCards.Remove(new Card(Suit.Hearts, FaceValue.Nine));
        discardCards.Add(new Card(Suit.Hearts, FaceValue.Nine));
        discardCards.Reverse();
        discardCards.Remove(new Card(Suit.Clubs, FaceValue.Ace));
        discardCards.Add(new Card(Suit.Clubs, FaceValue.Ace));
        CardPile discardPile = Utility.CreateCardPile(discardCards);

        CardPile drawPile = new CardPile(false);

        int originalNumCardsComputer = computerHand.GetCount();
        int originalNumCardsDiscardPile = discardPile.GetCount();

        CrazyEights.StartGame(
            userHand: userHand,
            computerHand: computerHand,
            discardPile: discardPile,
            drawPile: drawPile
        );

        CrazyEights.UserPlayCard(0);
        Console.WriteLine(CrazyEights.ComputerAction());

        /*
        Assert.AreEqual(
            CrazyEights.ActionResult.FlippedDeck,
            CrazyEights.ComputerAction()
        );

        Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Hearts, FaceValue.Nine)));
        Assert.AreEqual(originalNumCardsComputer, computerHand.GetCount());
        Assert.AreEqual(originalNumCardsDiscardPile, drawPile.GetCount());
        Assert.AreEqual(1, discardPile.GetCount());
        Assert.IsTrue(CrazyEights.IsPlaying);
        Assert.IsFalse(CrazyEights.IsUserTurn);
        */
        ExitProgram();
    }

    static void ExitProgram() {
        Console.Write("\nPress ENTER to exit. ");
        Console.ReadLine();
    }
}

public static class Utility {
    public static CardPile CreateCardPile(List<Card> cards) {
        CardPile cardPile = new CardPile();
        foreach (Card card in cards) {
            cardPile.AddCard(card);
        }
        return cardPile;
    }
    public static List<Card> FullDeckInOrder() {
        CardPile cardPile = new CardPile(true);
        List<Card> allCards = cardPile.DealCards(cardPile.GetCount());
        allCards.Reverse();
        return allCards;
    }
    public static void RemoveHand(List<Card> cards, Hand hand) {
        foreach (Card card in hand) {
            cards.Remove(card);
        }
    }
}
