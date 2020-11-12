<template>
  <div>
    <div class="container-lg">
      <div v-if="!EditVisible && !CreateVisible" class="table-responsive">
        <div class="table-wrapper">
          <div class="table-title">
            <div class="row">
              <div class="col-sm-8">
                <h2>Employee <b>Details</b></h2>
              </div>
              <div class="col-sm-4">
                <button @click="createVisibility()" type="button" class="btn btn-info add-new">
                  <i class="fa fa-plus"></i> Add New
                </button>
              </div>
            </div>
          </div>
          <table class="table table-bordered">
            <thead>
              <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Contact</th>
                <th>Company</th>
                <th>Service</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody v-for="lead in Leads">
              <Lead :lead="lead" @leadDeleted="reloadList()" @onEditClick="showEdit($event)"/>
            </tbody>
          </table>
        </div>
      </div>
      <div v-if="!CreateVisible && EditVisible">
      <EditPage :lead="Lead" @Edited="editVisibility()"/>
      </div>
      <div v-if="!EditVisible && CreateVisible">
      <CreateLead @Created="createVisibility()"/>
      </div>
    </div>
  </div>
</template>
<script>
import Lead from "./components/Lead.vue";
import EditPage from "./components/EditPage.vue";
import CreateLead from "./components/CreateLead.vue";
export default {
  name: "App",
  components: {
    Lead,
    EditPage,
    CreateLead
  },
  data() {
    return {
      Leads: [],
      EditVisible:false,
      CreateVisible:false,
      Lead: []
    };
  },
  mounted() {
    this.loadLeads();
  },
  methods: {
    editVisibility(){
        this.EditVisible = false;
    },
    createVisibility(){
        this.loadLeads();
        this.CreateVisible = !this.CreateVisible;
    },
      showEdit(lead)
      {
          this.Lead = lead;
          this.EditVisible=true;
      },
      reloadList(){
         this.loadLeads();
      },
    loadLeads() {
      fetch("/api/lead", {
        method: "GET",
      })
        .then((response) => response.json())
        .then((data) => {
          this.Leads = data;
        })
        .catch(() =>
          console.log("Can’t access " + url + " response. Blocked by browser?")
        );
    },
  },
};
</script>
