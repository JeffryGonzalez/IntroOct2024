import { TransactionRecord } from '../app/banking/types';

const initialState: TransactionRecord[] = [
  {
    id: 'd89d9641-4a24-47a1-9e1b-c45855a4ab0a',
    amount: 562.23,
    startingBalance: 0,
    newBalance: 562.23,
    type: 'deposit',
    created: 1729623072771,
  },
  {
    id: '0f44ef39-16d5-41ff-8214-7d9e826669b7',
    amount: 812.23,
    startingBalance: 562.23,
    newBalance: 1374.46,
    type: 'deposit',
    created: 1729623077419,
  },
  {
    id: '60358a6d-1c38-49df-ba05-48b77015a28f',
    amount: 15.23,
    startingBalance: 1374.46,
    newBalance: 1359.23,
    type: 'withdrawal',
    created: 1729623085091,
  },
  {
    id: '684683ac-bb24-4f15-a35b-75462c50c90c',
    amount: 19.23,
    startingBalance: 1359.23,
    newBalance: 1340,
    type: 'withdrawal',
    created: 1729623089718,
  },
  {
    id: '97b4ef70-75f4-4de8-b1b1-8dd75b73546e',
    amount: 420.69,
    startingBalance: 1340,
    newBalance: 1760.69,
    type: 'deposit',
    created: 1729623095591,
  },
];
