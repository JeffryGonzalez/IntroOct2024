import { HttpResponse, http } from "msw";
import { TransactionRecord } from "../app/banking/types";

const initialState: Omit<
  TransactionRecord,
  "startingBalance" | "newBalance"
>[] = [
  {
    id: "d89d9641-4a24-47a1-9e1b-c45855a4ab0a",
    amount: 562.23,
    type: "deposit",
    created: 1729623072771,
  },
  {
    id: "0f44ef39-16d5-41ff-8214-7d9e826669b7",
    amount: 812.23,
    type: "deposit",
    created: 1729623077419,
  },
  {
    id: "60358a6d-1c38-49df-ba05-48b77015a28f",
    amount: 15.23,
    type: "withdrawal",
    created: 1729623085091,
  },
  {
    id: "684683ac-bb24-4f15-a35b-75462c50c90c",
    amount: 19.23,
    type: "withdrawal",
    created: 1729623089718,
  },
  {
    id: "97b4ef70-75f4-4de8-b1b1-8dd75b73546e",
    amount: 420.69,
    type: "deposit",
    created: 1729623095591,
  },
];

const handlers = [
  http.get(
    "http://fake-api.bankohypertheory.com/user/statements/:year/:month",
    ({ params }) => {
      const openingBalance = initialState
        .map((a) => a.amount)
        .reduce((a, b) => a + b, 0);
      const response = {
        accountNumber: "1234567890",
        statementDate: `${params["year"]}-${params["month"]}`,
        openingBalance,
        transactions: initialState,
      };
      return HttpResponse.json(response);
    },
  ),
];

export default handlers;
