
<template>
  <form v-on:submit.prevent="">
  <div class="form-group">
    <label>Name</label>
    <input type="text" class="form-control" v-model="lead.name">
  </div>
  <div class="form-group">
    <label>Email</label>
    <input type="email" class="form-control" v-model="lead.email">
  </div>
  <div class="form-group">
    <label>Contact</label>
    <input type="text" class="form-control" v-model="lead.contact">
  </div>
  <div class="form-group">
    <label>Company</label>
    <input type="text" class="form-control" v-model="lead.company">
  </div>
<select v-model="lead.service_Id">
  <option v-for="service in Services" v-bind:value="service.service_Id">{{service.service_Name}}</option>
</select>
  <button type="button" v-on:click="editLead(lead)" class="btn btn-primary">Submit</button>
</form>
</template>
<script>
export default {
  props: ["lead"],
data() {
  return {
    Services: [],
  }
},
mounted() {
  this.loadServices();
},
methods: {
   editLead(lead) {
      fetch("/api/lead/" + lead.id, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          id: lead.id,
          name: lead.name,
          email: lead.email,
          contact: lead.contact,
          company: lead.company,
          service_Id: lead.service_Id,
        }),
      })
      .then(() => {
          this.$emit("Edited");
        })  
      .then((response) => response.json())
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
