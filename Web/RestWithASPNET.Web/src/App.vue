<template>
  <div class="d-menubar">
    <Menubar :model="items">
      <template #start>
        <img alt="logo" src="https://www.primefaces.org/wp-content/uploads/2020/05/placeholder.png" height="40" class="p-mr-2">
      </template>
    </Menubar>
  </div>
  <router-view />
</template>

<script>
import items from './data/menu';

  export default {
    name: 'App',
    data() {
      return {
        items,
        isBook: false
      }
    }
  }
</script>

<style lang="scss">
  body {
    background-color: #edf0f5;
    margin: 0;
  }
  #app {
    .d-menubar {
      .p-menubar {
        border: none;
        border-radius: 0;
        background: linear-gradient(90deg,#0388e5 0,#07bdf4);
      }
    }
  }
</style>
