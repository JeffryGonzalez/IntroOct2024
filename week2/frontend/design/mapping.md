# Mapping an API Response.

The api right now is telling us that the account has a starting balance of $118.23

We did a deposit of 562.23
We did a deposit of 812.23
We did a withdrawal of 15.23
We did a withdrawal of 19.23
We did a deposit of 420.69

What is our ending balance?

For each of those transactions, what was the balance _before_ that
individual transaction, and what was the balance _after_ that
individual transaction?

Oh, and they call the ID of the traction an `ibnTxLsn`, we call it `id`.

They call the date it was posted `postedOn` we call it `created`,
and we like to represent those as numbers (timestamp),
they did it as an ISO8601 Formatted String.
