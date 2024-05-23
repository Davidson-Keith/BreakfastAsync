namespace BreakfastAsync.BreakfastItems;

public class Toast : BreakfastItem{
  public Toast(int slices, string finishedMessage = "toast is ready") {
    NumberOfItems = slices;
    FinishedMessage = finishedMessage;
  }

  public async void MakeToastFail() {
    MakeToastAsync(); // Without Await, fails to work properly. Program exits before "Remove toast from toaster".
    ApplyButter();
    await Task.Delay(1500); // Program exits before this is finished timing down.
    ApplyJam(); // Never called, as program exits first
  }
  public async Task<Toast> MakeToastAsync() {
    var toast = await ToastBreadAsync();
    // var toast = ToastBreadAsync(); // Doesn't work, needs await to become a Task<Toast>, rather than just a Toast.
    ApplyButter();
    return toast;
  }

  public void ApplyJam() =>
    Console.WriteLine("Putting jam on the toast");

  public void ApplyButter() =>
    Console.WriteLine("Putting butter on the toast");

  public async Task<Toast> ToastBreadAsync() {
    for (int slice = 0; slice < NumberOfItems; slice++) {
      Console.WriteLine("Putting a slice of bread in the toaster");
    }
    Console.WriteLine("Start toasting...");
    await Task.Delay(1000);
    Console.WriteLine("Remove toast from toaster");
    
    // "this" is actually a Toast object, not a Task<Toast> object.
    // The "async" keyword in the method signature is the magic wraps it into a Task<Toast> object
    // Note, it is still merely a Toast object, and requires the caller to use "await" in the call.
    // This async-await then causes that thread to pause and wait for the Task to finish before continuing.
    return this;  
  }
}
