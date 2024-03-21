
static int UpdateVal(int originalAmount, int incrementAmount, bool add) {
    if (add)
    {
        return originalAmount + incrementAmount;
    }
    else
    {
        return originalAmount - incrementAmount;
    }
}

string filePath = "input/input.txt";

var data = File.ReadAllLines(filePath);

Dictionary<string, int> registers = new() { };

List<int> highest = [];

foreach (string line in data)
{

    var d = line.Split();
    Instruction instruction = new Instruction(
        UpdateLocation: d[0],
        Inc: d[1] == "inc",
        UpdateAmount: int.Parse(d[2]),
        ConditionalLocation: d[4],
        Conditional: d[5],
        ConditionalAmount: int.Parse(d[6])
    );
    Console.WriteLine(instruction);

    int ConditionalExistingVal;

    // Check the conditional location in the dictionary
    if (!registers.TryGetValue(instruction.ConditionalLocation, out ConditionalExistingVal))
    {
        ConditionalExistingVal = 0; // Assign default value of 0 if the key doesn't exist
        registers[instruction.ConditionalLocation] = ConditionalExistingVal; // Update dictionary with default value
    
    }
    
    int UpdateExistingVal;
    
    // Check the update location in the dictionary
    if (!registers.TryGetValue(instruction.UpdateLocation, out UpdateExistingVal))
    {
        UpdateExistingVal = 0; // Assign default value of 0 if the key doesn't exist
        registers[instruction.UpdateLocation] = UpdateExistingVal; // Update dictionary with default value
    }
    switch (instruction.Conditional) {
        case "==":
            if (ConditionalExistingVal == instruction.ConditionalAmount)
        {
            registers[instruction.UpdateLocation] = UpdateVal(UpdateExistingVal, instruction.UpdateAmount, instruction.Inc);
        }
        break;
        case ">=":
            if (ConditionalExistingVal >= instruction.ConditionalAmount)
        {
            registers[instruction.UpdateLocation] = UpdateVal(UpdateExistingVal, instruction.UpdateAmount, instruction.Inc);

        }
            break;
        case ">":
            if (ConditionalExistingVal > instruction.ConditionalAmount)
        {
            registers[instruction.UpdateLocation] = UpdateVal(UpdateExistingVal, instruction.UpdateAmount, instruction.Inc);

        }
            break;
        case "<":
            if (ConditionalExistingVal < instruction.ConditionalAmount)
        {
            registers[instruction.UpdateLocation] = UpdateVal(UpdateExistingVal, instruction.UpdateAmount, instruction.Inc);

        }
            break;
        case "<=":
            if (ConditionalExistingVal <= instruction.ConditionalAmount)
        {
            registers[instruction.UpdateLocation] = UpdateVal(UpdateExistingVal, instruction.UpdateAmount, instruction.Inc);
        }
            break;
        case "!=":
            if (instruction.ConditionalAmount != ConditionalExistingVal)
        {
            registers[instruction.UpdateLocation] = UpdateVal(UpdateExistingVal, instruction.UpdateAmount, instruction.Inc);

        }
            break;
        default:
            Console.WriteLine("Invalid Input");
            break;
    }
    highest.Add(registers.Values.Max());
}

foreach (KeyValuePair<string, int> kvp in registers)
{
    Console.WriteLine(kvp.Value + kvp.Key);
}

Console.WriteLine(highest.Max());

public record Instruction(
    string UpdateLocation, 
    bool Inc, 
    int UpdateAmount, 
    string ConditionalLocation, 
    string Conditional,
    int ConditionalAmount);

