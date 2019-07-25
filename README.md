# Canducci.Recurrence

### Create Plan
#### C#

```Csharp
const string clientId = "";
const string clientSecret = "";
Login login = new Login(clientId, clientSecret);
Plan plan = new Plan(login);
Body body = new Body("Plano Teste 001", 1, null);
PlanResponse planResponse = plan.Create(body);
if (planResponse.Status) // Foi criado o plano com sucesso
{
    //planResponse.Code;
    //planResponse.Name;
    //planResponse.Interval;
    //planResponse.PlanId;
    //planResponse.Repeats;
    //planResponse.Status;
    //planResponse.CreatedAt;                
}
```

#### VB.NET

```VB
Const clientId As String = ""
Const clientSecret As String = ""
Dim login = New Login(clientId, clientSecret)
Dim plan = New Plan(login)
Dim body = New Body("Plano Teste 001", 1, vbNull)
Dim planResponse As PlanResponse = plan.Create(body)
If planResponse.Status Then
    'planResponse.Code;
    'planResponse.Name;
    'planResponse.Interval;
    'planResponse.PlanId;
    'planResponse.Repeats;
    'planResponse.Status;
    'planResponse.CreatedAt;
End If
```
