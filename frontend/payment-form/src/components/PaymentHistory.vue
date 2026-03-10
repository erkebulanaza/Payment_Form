<script>
import {onMounted, ref} from "vue";
import {paymentHistory} from "@/api/paymentApi.js";

export default {
  setup() {
    const payments = ref([])

    const loadPaymentsHistory = async () => {
      payments.value = await paymentHistory()
    }
    onMounted(loadPaymentsHistory)
    return {
      payments,
      loadPaymentsHistory
    }
  }
}

</script>

<template>
  <div>
    <table class="payment-table">
      <thead>
      <tr>
        <th>№</th>
        <th>Wallet</th>
        <th>Amount</th>
        <th>Account</th>
        <th>Email</th>
        <th>Phone</th>
        <th>Currency</th>
        <th>Date</th>
        <th>Status</th>
        <th>Comment</th>
      </tr>
      </thead>

      <tbody>
      <tr v-for="(p, i) in payments" :key="p.id">
        <td>{{ i + 1}}</td>
        <td>{{ p.walletNumber }}</td>
        <td>{{ p.amount }}</td>
        <td>{{ p.accountId }}</td>
        <td>{{ p.email }}</td>
        <td>{{ p.phone || '-' }}</td>
        <td>{{ p.currency }}</td>
        <td>{{ p.createdAt}}</td>
        <td>
          <span>{{ p.status }}</span>
        </td>
        <td>{{ p.comment || '-' }}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<style>
.payment-table td {
  padding: 10px;
  border-bottom: 1px solid #ddd;
}
</style>