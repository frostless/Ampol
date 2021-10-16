# Ampol API

This is a Web API project for demo purpose only.

For simplicity it uses fake hard-code data and it has no Auth in place.

## Requirements

Dotnet Core 5 and a Rest client.

## Usage

### Request

`Post /api/v1/Counter/Checkout`

    curl -L -X POST 'http://localhost:9579/api/v1/Counter/Checkout' -H 
    'Content-Type: application/json' --data-raw '{
    "customerId": "8e4e8991-aaee-495b-9f24-52d5d0e509c5",
    "loyaltyCard": "CTX0000001",
    "transactionDate": "2020-01-03T00:00:00.000Z",
    "baskets": [
        {
            "productId": "PRD01",
            "unitPrice": 1.2,
            "quantity": 3
        },
        {
            "productId": "PRD02",
            "unitPrice": 2.0,
            "quantity": 2
        },
        {
            "productId": "PRD03",
            "unitPrice": 5.0,
            "quantity": 1
        }
      ]
     }


### Response

    {
        "customerId": "8e4e8991-aaee-495b-9f24-52d5d0e509c5",
        "loyaltyCard": "CTX0000001",
        "transactionDate": "2020-01-03T00:00:00Z",
        "totalAmount": 12.6,
        "discountApplied": 0.80,
        "grandTotal": 11.80,
        "pointsEarned": 26
    }