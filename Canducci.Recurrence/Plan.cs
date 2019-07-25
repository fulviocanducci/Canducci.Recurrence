namespace Canducci.Recurrence
{
    using System;    
    using System.Globalization;
    public class Plan
    {
        private Login Login { get; }        
        public Plan(Login login)
        {
            Login = login;
        }
        public PlanResponse Create(Body body)
        {            
            var result = Login.EndPoints.CreatePlan(null, body.ToObject());            
            if (result.code == 200)
            {
                return new PlanResponse(
                        result.code,
                        result.data.plan_id,
                        result.data.name,
                        result.data.interval,
                        result.data.repeats,
                        DateTime.ParseExact(result.data.created_at, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                    );
            }
            return new PlanResponse(result.code);
        }

        public SubscriptionBodyResponse CreateSubscription(int planId, SubscriptionBody items)
        {
            var param = new
            {
                id = planId
            };            
            var result = Login.EndPoints.CreateSubscription(param, items.ToObjects());
            //{
            //  "code": 200, // retorno HTTP "200" informando que o pedido foi bem sucedido
            //  "data": {
            //    "subscription_id": numero_subscription_id, // número ID referente à inscrição gerada
            //    "status": "new", // cobrança gerada, aguardando definição da forma de pagamento
            //    "custom_id": null, // identificador próprio opcional
            //    "charges": [
            //      {
            //        "charge_id": numero_charge_id, // número da ID referente à transação gerada
            //        "status": "new", // cobrança gerada, aguardando definição da forma de pagamento
            //        "total": 6990, // valor total da transação (em centavos, sendo 6990 = R$69,90)
            //        "parcel": 1 // número de parcelas
            //      }
            //    ],
            //    "created_at": "2016-06-29 10:42:59" // data e hora da criação da transação
            //  }
            //}
            return new SubscriptionBodyResponse(
                result.code,
                result.data.subscription_id,
                result.data.status,
                result.data.customId,
                result.data.charges,
                DateTime.ParseExact(result.data.created_at, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                );
        }
    }
}
