using BreakfastAsync.BreakfastItems;

namespace BreakfastAsync {
  /**
   * Playing with Microsoft's Learning page "Asynchronous programming with async and await":
   * https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
   *
   * See:
   * https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model
   * https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
   */
  class Program {
    static void Main(String[] args) {
      // MakeBreakfast();
      MakeBreakfastFail();
    }

    // static async Task Main(String[] args) { 
    // The tutorial used the above line, but the below works fine. 
    static void MakeBreakfast() {
      Console.WriteLine("---------\nMakeBreakfast() called");
      new Coffee().PourCoffee();
      Task eggsTask = new Eggs(2).FryEggsAsync();
      Task baconTask = new Bacon(3).FryBaconAsync();
      Task toastTask = new Toast(2).MakeToastAsync();
      Task.WaitAll([eggsTask, baconTask, toastTask]);
      
      // This is how they did it in the tutorial, but the single line above does the same.
      // List<Task> breakfastTasks = [eggsTask, baconTask, toastTask];
      // while (breakfastTasks.Count > 0) {
      //   Task finishedTask = await Task.WhenAny(breakfastTasks);
      //   // await finishedTask;
      //   breakfastTasks.Remove(finishedTask);
      // }
      new Juice().PourOJ();
      Console.WriteLine("Breakfast is ready!");
    }

    static void MakeBreakfastFail() {
      Console.WriteLine("---------\nMakeBreakfastFail() called");
      new Coffee().PourCoffee();
      // Task.WaitAll([Toast(2).MakeToastFail()]); Can't do this, because MakeToastFail() doesn't return a Task.
      new Toast(2).MakeToastFail(); // This doesn't get to complete before program carries on and exits.
      new Juice().PourOJ();
      Console.WriteLine("Breakfast is ready!");
    }
  }
}

  
  