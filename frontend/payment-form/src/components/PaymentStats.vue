<script>
import {onMounted, ref} from "vue";
import {paymentStats} from "@/api/paymentApi.js";

export default {
  setup() {
    const stats = ref([])

    const getStats = async () => (
        stats.value = await paymentStats()
    )

    onMounted(getStats)
    return {
      stats,
      getStats
    }
  }
}
</script>

<template>
  <div v-if="stats">
    <div>
      <div>
        <h3>Total Payments</h3>
        <p>{{ stats.totalCount }}</p>
      </div>
      <div class="card">
        <h3>Total Amount</h3>
        <p>{{ stats.totalAmount }}</p>
      </div>
    </div>
    <table class="stats-table">
      <thead>
      <tr>
        <th>Date</th>
        <th>Count</th>
        <th>Amount</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="d in stats.daily" :key="d.date">
        <td>{{d.date}}</td>
        <td>{{ d.count }}</td>
        <td :class="{negative: d.amount < 0}">
          {{ d.amount }}
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<style>
.container{
  display: block;
}
.stats-table td{
  padding:10px;
  border-bottom:1px solid #ddd;
}
</style>