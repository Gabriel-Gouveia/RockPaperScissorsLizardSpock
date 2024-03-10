# Rock-Paper-Scissors-Spock-Lizard Game on C# #

# 1- Rules #
The game is similar to rock-paper-scissors. The main difference is that there are two more entities: Spock and lizard. <br>
It is a clear reference to The Big Bang Theory series from Warner Bros. It is a nice series. <br>
Since there are two more entities in the game, some rules were added. <br>
<br>
All rules: <br>
<br>
- Rock smashes scissors <br>
- Scissors cuts paper <br>
- Paper wraps rock <br>
- Rock crushes lizard <br>
- Lizard poisons Spock <br>
- Spock breaks scissors <br>
- Scissors beheads lizard <br>
- Lizard eats paper <br>
- Paper refutes Spock <br>
- Spock vaporizes rock <br>
<br>

# 2- Criteria #
The application had to be developed accordingly to the following criteria: <br>
<br>
- The framework must be .NET Core
- The language must be C#
- The application must be an API
- Dependency Injection is mandatory
- Use the Design Patterns that you think that will suit the solution
- The code must be totally written in English
- A single method must receive two parameters: player one's choice and player two's choice
- All possible results must be processed
<br>

**Note:** The project's .NET version is 5.0. It is because my computer is kinda old (Windows 8.1) and I am not able to install newer .NET versions.
<br>
<br>

# 3- Approach #
The game is actually quite easy to implement. The real challenge here is when you wish to prevent yourself from writing bad code. I mean, this application could be done within 5 or 10 minutes if you don't care about maintainability, Clean Code, low coupling, SOLID principles and readability. <br>
If you want to implement this game and ensure that the code you write is maintainable, readable and follows principles like Clean Code, KISS, YAGNI and SOLID, how would you code it? <br>
My first step was to review about Design Patterns and figure out the one that suits the best for this implementation. The **Strategy pattern** made sense to me. <br>
The Strategy pattern allows me to encapsulate algorithms within separate classes. Each class is named as "strategy". <br>
The main class, which is named as "Context", is the class that processes a specific task in several different ways. <br>
The Strategy pattern suggests the developer to extract those algorithms to different strategy classes. <br>
The advantage is that the Context class will not turn into a huge class, since it delegates its task to a separate strategy object. <br>
The Context is not responsible for selecting an algorithm to be processed. It is the client who selects a strategy and passes it to the context. Through a generic interface, the Context accesses a method to trigger the algorithm which is encapsulated in the selected strategy. <br>
By using the Strategy pattern, it is possible to add new algorithms or modify the existent ones without changing the Context code or other strategies. <br>
For the Rock-Paper-Scissors-Spock-Lizard game, the Strategy pattern is useful because it separates the IF statements that are necessary to determine the winner. <br>
<br>
<br>

# 3.1- Strategies #
As I implemented this game, one strategy represents one round, one case, one pair of choices or one possibility. Name it as you like. <br>
One round is when two players play once. The possibility is a pair, which is made up by the player one's choice and player two's choice. <br>
When a single round is played, there are ten possibilities of pairs of choices: <br>

<br>

- Lizard and paper
- Lizard and Spock
- Paper and rock
- Paper and Spock
- Rock and lizard
- Rock and scissors
- Scissors and lizard
- Scissors and paper
- Spock and rock
- Spock and scissors

<br>

A strategy is a possible pair of choices, like those mentioned in the list above. The order does not matter, i.e., there is no strategy for "paper and lizard" case since "lizard and paper" strategy already exists. What is taken under consideration is the possible pair of choices, and not the player who made a choice. This would generate some redundancy. <br>
Each strategy encapsulates an IF and an ELSE instructions that determines the winner. The strategy is only selected and run if both players made choices that resulted in its possibility. For example, when the player one chooses "scissors" and player two chooses "paper", then the "ScissorsPaperStrategy" is selected and run. If the player two had chosen "scissors" and the player one had chosen "paper", the strategy would be the same. There are no redundant strategies. <br>
<br>
Strategy example: <br>
<br>

```csharp
public class LizardSpockStrategy : IGameStrategy
    {
        public string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice)
        {
            if (playerOneChoice == Choice.LIZARD)
                return "Player one is the winner!";
            else
                return "Player two is the winner!";
        }
    }
```

<br>
<br>

# 3.2- Strategy selection: Chain of Responsibility pattern #
In order to the strategy pattern work, a strategy has to be selected and passed into the Context through the "SetStrategy" method. <br>
At first, I had thought of a "StrategySelectorService", which would store tuples of choices within a dictionary and a method within this service would select the strategy by reading the choices parameters and checking whether those choices match a tuple from the dictionary or not. However, it didn't work, because the creation of key-value pairs was too much redundant and polluter. <br>
Afterwards, I thought about one Design Pattern I'm familiar with: **Chain of Responsibility.** <br>
The Chain of Responsibility pattern chains handler objects that either process the request or send it to their next handler. <br>
I couldn't think of another way to create a strategies selector. <br>
In the Chain of Responsibility pattern I implemented, each handler returns a strategy, i.e., each handler is dedicated to select its corresponding strategy. The current handler checks whether both choices, no matter the player, correspond to the handler's strategy or not. <br>
<br>
As an example, check the code bellow:
<br>
<br>

```csharp
public class PaperRockHandler : Handler
    {
        public override IGameStrategy Handle(Choice playerOneChoice, Choice playerTwoChoice)
        {
            if ((playerOneChoice == Choice.PAPER && playerTwoChoice == Choice.ROCK) ||
                (playerOneChoice == Choice.ROCK && playerTwoChoice == Choice.PAPER))
            {
                return new PaperRockStrategy();
            }
            else
                return base.Handle(playerOneChoice, playerTwoChoice);
        }
    }
```

<br>
The current handler is the "PaperRockHandler". If both players choose "paper" and "rock" choices, then the current handler will return a "PaperRockStrategy" object. Otherwise, if the players' choices do not match what the current handler is expecting, the handler will pass both Choice parameters to the next handler by invoking the "Handle" method from the base Handler. <br>
Suddenly, I ran into the following issue: where should I point to all next handlers? I need to have the first handler, who will point to its next handler, and the next handler will point to another next handler. Where should I code it? <br>
For this, the solution I found was to create a service that would have an "entry point" role within the Chain of Responsibility pattern. I named it as "InitializeChainOfResponsibilityService". <br>
<br>
<br>

```csharp
public class InitializeChainOfResponsibilityService : IInitializeChainOfResponsibilityService
    {
        private LizardPaperHandler _firstHandler = new LizardPaperHandler();

        public InitializeChainOfResponsibilityService()
        {
            _firstHandler.SetNext(new LizardSpockHandler())
                         .SetNext(new PaperRockHandler())
                         .SetNext(new PaperSpockHandler())
                         .SetNext(new RockLizardHandler())
                         .SetNext(new RockScissorsHandler())
                         .SetNext(new ScissorsLizardHandler())
                         .SetNext(new ScissorsPaperHandler())
                         .SetNext(new SpockRockHandler())
                         .SetNext(new SpockScissorsHandler());
        }

        public IHandler GetFirstHandler()
        {
            return _firstHandler;
        }
    }
```

<br>
<br>
In this service, I hard-coded the first handler by the alphabetical order. Afterwards, I declared a constructor method that would bind all handlers through the "next" pointer. Finally, this service returns the first handler when the "GetFirstHandler" method is invoked.<br> 
When the "GetFirstHandler" is invoked in the GameController, it returns the first handler. Thereafter, the "Handle" method is invoked right away, which runs the Chain of Responsibility sequence and returns the correct strategy according to the received parameters: <br> 
<br>

```csharp
IGameStrategy gameStrategy = _initializeChainOfResponsibilityService.GetFirstHandler().Handle(playerOneValidChoice, playerTwoValidChoice);
_gameContext.SetStrategy(gameStrategy);
return Ok(_gameContext.DefineWinner(playerOneValidChoice, playerTwoValidChoice));
```

<br>
The gameContext object sets the correct strategy, which makes it possible to determine a winner.
<br>
<br>

# 4- Validation #


