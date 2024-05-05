# Domain Models

## Training

```csharp
class Training {
  Training Create(string name, string description);
  void Update(string name, string description, List<Set> sets);
}
```

```json
{
  "Id": "00000000-0000-0000-0000-000000000000",
  "Name": "Training 1",
  "Description": "Description of training 1",
  "NumberOfExercises": 5,
  "Duration": 60,
  "Sets": [
    {
      "Id": "00000000-0000-0000-0000-000000000000",
      "Description": "Description of set 1",
      "Repetitions": 10,
      "Time": 60,
      "ExerciseIds": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
      ]
    },
    {
      "Id": "00000000-0000-0000-0000-000000000000",
      "Description": "Description of set 2",
      "Repetitions": 10,
      "Time": 60,
      "ExerciseIds": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
      ]
    }
  ],
}
```

## Exercise

```csharp
class Exercise {
  Exercise Create(string name, string description, Image photo, PartId partId);
  void Update(string name, string description, Image photo, PartId partId);
}
```

```json
{
  "Id": "00000000-0000-0000-0000-000000000000",
  "Name": "Exercise 1",
  "Description": "Description of exercise 1",
  "Photo": "https://www.example.com/photo.jpg",
  "PartId": "00000000-0000-0000-0000-000000000000"
}
```

## Part

```csharp
class Part {
  Part Create(string name, string description);
  void Update(string name, string description);
  void AddExercise(Exercise exercise);
  void RemoveExercise(Exercise exercise);
}
```

```json
{
  "Id": "00000000-0000-0000-0000-000000000000",
  "Name": "Part 1",
  "Description": "Description of part 1",
  "ExerciseIds": [
    "00000000-0000-0000-0000-000000000000",
    "00000000-0000-0000-0000-000000000000",
    "00000000-0000-0000-0000-000000000000"
  ]
}
```

## Execution

```csharp
class Execution {
  Execution Create(Guid trainingId, Guid userId, Guid trainerId, DateTime dateToComplete);
  void Complete();
}
```

```json
{
  "Id": "00000000-0000-0000-0000-000000000000",
  "TrainingId": "00000000-0000-0000-0000-000000000000",
  "UserId": "00000000-0000-0000-0000-000000000000",
  "TrainerId": "00000000-0000-0000-0000-000000000000",
  "DateToComplete": "2021-01-01T00:00:00",
  "CompletionDate": "2023-01-01T00:00:00",
  "Completed": true
}
```