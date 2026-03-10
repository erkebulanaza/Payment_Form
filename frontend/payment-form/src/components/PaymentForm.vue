<script>
import {ref} from "vue";
import { createPayment } from '../api/paymentApi.js';

export default {
  setup() {
    const walletNumber = ref("")
    const amount = ref(0)
    const accountId = ref(0)
    const email = ref("")
    const phone = ref("")
    const currency = ref("USD")
    const comment = ref("")
    const apiKey = ref("")
    const showApiKeyInput = ref(false)
    const message = ref("")

    const submitPayment = async () => {

      if (!apiKey.value) {
        showApiKeyInput.value = true
        return;
      }

      const payment = {
        WalletNumber: walletNumber.value,
        Amount: parseFloat(amount.value),
        AccountId: parseInt(accountId.value),
        Email: email.value,
        Phone: phone.value,
        Currency: currency.value,
        Comment: comment.value,
        CreatedAt: new Date(),
        Status: 0,
      }

      try{
        await createPayment(payment, apiKey.value)
        message.value = "Payment created successfully."
      }catch(err){
        alert(err)
        message.value = "Something went wrong."
      }
    }
    return {
      walletNumber,
      amount,
      accountId,
      email,
      phone,
      currency,
      comment,
      showApiKeyInput,
      apiKey,
      message,
      submitPayment,
    }
  }
}

</script>

<template>
  <div class="payment-container">
    <form @submit.prevent="submitPayment" class="form-horizontal">
      <div class="row">
        <p>Enter Wallet Number </p><input v-model="walletNumber" required />
      </div>
      <div class="row">
        <p>Enter Account ID </p><input v-model="accountId" placeholder="Account ID" required />
      </div>
      <div class="row">
        <p>Enter Email </p><input v-model="email" required type="email" />
      </div>
      <div class="row">
        <p>Enter Amount </p><input v-model="amount" required />
      </div>
      <div class="row">
        <p>Select currency</p>
        <select v-model="currency" class="select">
          <option value="USD">USD</option>
          <option value="EUR">EUR</option>
          <option value="RUB">RUB</option>
          <option value="KZT">KZT</option>
        </select>
      </div>
      <div class="row">
        <p>Enter Phone</p><input v-model="phone" />
      </div>
      <div class="row">
        <p>Enter Comment</p><input v-model="comment"/>
      </div>
      <div v-if="showApiKeyInput" class="row">
        <p>Enter API Key</p><input v-model="apiKey" type="password"/>
      </div>
      <button type="submit">Create Payment</button>
    </form>
    <div>
      {{message}}
    </div>
  </div>
</template>

<style>
.payment-container {
  width: 100%;
  display: flex;
}
.form-horizontal{
  display: flex;
  flex-direction: column;
}
.row{
  display: flex;
  justify-content: space-between;
  height: 35px;
}
.row input{
  margin: 5px;
}
.select{
  width: 50%;
}
</style>
