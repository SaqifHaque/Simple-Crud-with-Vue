<template>
      <tr>
        <td>{{ lead.name }}</td>
        <td>{{ lead.email }}</td>
        <td>{{ lead.contact }}</td>
        <td>{{ lead.company }}</td>
        <td>{{ lead.service.service_Name }}</td>
        <td>
          <button v-on:click="removeLead(lead)" type="button" class="btn-danger">Remove</button>
          <button v-on:click="editLoad(lead)" class="btn btn-info" type="button">Edit</button>
        </td>
      </tr>
</template>
<script>
export default {
  props: ["lead"],
  methods: {
    editLoad(lead){
      this.$emit("onEditClick",lead);
    },
      removeLead(lead) {
      fetch("/api/lead/" + lead.id, {
        method: "DELETE",
      }).then(() => {
        this.$emit("leadDeleted");
      });
    },
    editLead(lead) {
      fetch("/api/Lead/" + lead.id, {
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
      }).then((response) => response.json());
    }
  },
};
</script>
