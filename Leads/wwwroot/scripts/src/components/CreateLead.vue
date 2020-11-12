<template>
  <form v-on:submit.prevent="">
  <div class="form-group">
    <label>Name</label>
    <input type="text" class="form-control" v-model="name">
  </div>
  <div class="form-group">
    <label>Email</label>
    <input type="email" class="form-control" v-model="email">
  </div>
  <div class="form-group">
    <label>Contact</label>
    <input type="text" class="form-control" v-model="contact">
  </div>
  <div class="form-group">
    <label>Company</label>
    <input type="text" class="form-control" v-model="company">
  </div>
<select v-model="selected">
  <option v-for="service in Services" v-bind:value="service.service_Id">{{service.service_Name}}</option>
</select>
  <button type="button" v-on:click="onAddClicked()" class="btn btn-primary">Submit</button>
</form>
</template>
<script>
export default {
data() {
  return {
    Services: [],
    selected: '',
    name:'',
    email:'',
    contact:'',
    company:''
  }
},
mounted() {
  this.loadServices();
},
methods: {
   onAddClicked() {
      fetch("/api/lead", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          name: this.name,
          email: this.email,
          contact: this.contact,
          company: this.company,
          service_Id: this.selected,
        }),
      })
      .then((response) => response.json())
      .then(() => {
        this.$emit("Created");
      });
    },
  loadServices(){ 

    fetch("/api/service", {
        method: "GET",
      })
        .then((response) => response.json())
        .then((data) => {
          this.Services = data;
        })
       
        .catch(() =>
          console.log("Can’t access " + url + " response. Blocked by browser?")
        );
  }
},
}
</script>
